# ⏱️ MediTrack

**MediTrack** es un sistema de escritorio (C# y Windows Forms) para controlar la asistencia del personal de una clínica. Registra ingresos y salidas, calcula tardanzas, gestiona justificaciones y genera reportes para Recursos Humanos.

> Versión 2 – Hito 02.

## Integrantes del proyecto
- Huamán Flores, Alexis Miguel
- Mogollon Giol, Juan Mateo
- Peña Roña, Antony Yomar
- Peralta Marquina, Mathias Fabian
- Romero Canchanya, Daniela Katte

## Tecnologías
- C# con Windows Forms en .NET Framework 4.7.2
- SQL Server (base de datos `dbMediTrack`)
- Entity Framework 6.5.2 (modelo Database First, archivo `MediTrackModel.edmx`)
- Visual Studio 2022

## Arquitectura en 3 capas
La solución `MediTrack.slnx` tiene tres proyectos.

- `Datos/` Acceso a datos. Contiene el modelo de Entity Framework y una clase por entidad: `DArea`, `DTurno`, `DPersonal`, `DAsistencia` y `DJustificacion`.
- `Negocio/` Reglas del sistema. Cada clase usa su clase de datos: `NArea`, `NTurno`, `NPersonal`, `NAsistencia`, `NJustificacion`, `NReporte`, `NSesion` y `NServicioPassword`.
- `Presentacion/` Pantallas (Windows Forms). Es el proyecto de inicio.

Las entidades del modelo son `Area`, `Turno`, `Personal`, `RegistroAsistencia` y `Justificacion`. Todas guardan datos de auditoría (fechas de creación y modificación, y quién las hizo).

## Contraseñas
- Las contraseñas nuevas se guardan como hash PBKDF2-SHA256 dentro del campo `Password` existente; el usuario continúa escribiendo su contraseña normal.
- No se agregaron columnas ni se modificó la estructura de la base de datos. Las contraseñas existentes fueron migradas usando temporalmente el formato `usuario + "123"`.

## Cómo ejecutarlo
1. Abre SQL Server Management Studio y ejecuta el archivo `SCRIPT MEDITRACK + DATOS.sql`. Crea la base de datos `dbMediTrack`, sus tablas, procedimientos almacenados y datos de ejemplo.
2. Abre `MediTrack.slnx` con Visual Studio 2022. Restaura los paquetes NuGet si lo pide.
3. Revisa la cadena de conexión `dbMediTrackEntities` en el `App.config` de `Presentacion`. Por defecto usa `data source=.` y seguridad integrada de Windows. Cámbiala si tu servidor tiene otro nombre.
4. Deja `Presentacion` como proyecto de inicio y pulsa **Iniciar**.

## Datos para prueba
- `admin` / `admin123` – Administrador
- `rrhh` / `rrhh123` – Recursos Humanos
- `lvega` / `lvega123` – Enfermero (código `ENF002`)
- `crojas` / `crojas123` – Personal (código `PER001`)

La base trae 52 personas, 305 registros de asistencia y justificaciones de ejemplo, para que los reportes y gráficos ya muestren datos.

## Módulos
- **Login:** valida usuario y contraseña contra el hash guardado. Solo entran usuarios activos.
- **Menú principal:** muestra el nombre y rol de quien inició sesión. Los menús Mantenimiento y Jornadas solo se ven para Administrador y RRHH.
- **Marcar asistencia:** el personal escribe su código para registrar ingreso o salida.
- **Mantenimiento:** Personal, Áreas y Turnos (registrar, modificar, activar y desactivar).
- **Jornadas:** programar jornadas por persona o a todo el personal.
- **Justificaciones:** registrar, aprobar y rechazar.
- **Reportes estadísticos:** resumen de asistencia e incidencias diarias, con filtros por fechas, área y persona.
- **Gráficos:** distribución de asistencia (circular), evolución del ausentismo (líneas) y tardanza por área (columnas).

## Flujo de prueba
1. Inicia sesión con `rrhh`. Entra a **Jornadas** y usa la opción de programar a todos para la fecha de hoy.
2. En el menú pulsa **Marcar asistencia**, escribe un código (por ejemplo `ENF002`) y registra el ingreso y luego la salida.
3. Entra a **Justificaciones** para aprobar o rechazar las pendientes.
4. Abre **Reportes estadísticos** y **Gráficos** para ver los resultados.

El ingreso solo se permite si la persona tiene una jornada programada para ese horario.

## Reglas de negocio
- **Áreas y turnos:** el nombre y la descripción son obligatorios y no se repiten. No se puede desactivar un área o turno que tenga personal activo.
- **Turnos:** la hora de inicio y fin no pueden ser iguales y la tolerancia no puede ser negativa. Los turnos son Mañana (07:00–15:00), Tarde (15:00–23:00) y Noche (23:00–07:00 del día siguiente), con 10 minutos de tolerancia.
- **Personal:** código, nombres, apellidos, usuario, contraseña, rol, área y turno son obligatorios. El código y el usuario no se repiten. Nadie puede desactivar su propio usuario. No se activa a alguien cuya área o turno estén inactivos.
- **Asistencia:** no se programan dos jornadas el mismo día para la misma persona. Al ingresar fuera de la tolerancia, el registro queda como Tardanza y se guardan los minutos. Al marcar salida se calculan las horas trabajadas. Las jornadas sin ingreso que ya terminaron pasan a Falta.
- **Justificaciones:** tipos disponibles: Enfermedad, Cita médica, Permiso personal, Emergencia familiar y Otro. Cada jornada admite una sola justificación. Solo Administrador y RRHH pueden aprobar o rechazar, y solo las que están Pendientes. Una justificación aprobada no cuenta como falta en los reportes.
- **Roles:** Administrador y RRHH gestionan el sistema. Los demás roles (Médico, Enfermero, Personal) marcan su asistencia.
