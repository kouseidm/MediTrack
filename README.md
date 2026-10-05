# ⏱️MediTrack 
**Meditrack** es un sistema de escritorio (C# y Windows Forms) para controlar la asistencia del personal de una clínica: registra ingresos y salidas, calcula tardanzas y genera reportes para Recursos Humanos.

## Integrantes del proyecto
- Huamán Flores, Alexis Miguel
- Mogollon Giol, Juan Mateo
- Peña Roña, Antony Yomar
- Peralta Marquina, Mathias Fabian
- Romero Canchanya, Daniela Katte

## Datos para prueba

| Usuario | Clave    | Rol              |
|---------|----------|------------------|
| admin   | admin123 | Administrador    |
| rrhh    | rrhh123  | Recursos Humanos |
| lvega   | enf123   | Personal (código ENF001) |
| crojas  | eme123   | Personal (código EME001) |

## Estructura
- `Entities/`      Clases del diagrama (Area, Turno, Personal, RegistroAsistencia, Justificacion, Reportes) + EntidadBase (auditoría).
- `Repositories/`  Acceso a datos: una interfaz y una clase por entidad 
- `Services/`      Lógica del proyecto: cada servicio usa su repositorio.
- `Forms/`         Pantallas: Login, Menú, Marcación, Personal, Áreas, Turnos, Jornadas, Justificaciones, Reportes, Gráficos.

## Flujo de prueba
1. Login `rrhh` → "Programar jornadas" → "Programar a todos" (fecha de hoy).
2. Login (botón "Marcar asistencia") → código `ENF001` → Registrar ingreso / salida.
3. "Reportes" → Generar / Ver gráficos.

## Lógica incluida (Services)
- `AreaService`, `TurnoService`, `PersonalService`: registrar, actualizar/modificar, desactivar, listar y buscar. Validan nombres repetidos, códigos de 4 a 10 caracteres y que no se desactive un área o turno con personal activo.
- `AsistenciaService`: programar jornadas (una persona o todos), validar superposición, registrar ingreso y salida, calcular tardanza y horas, y marcar faltas automáticamente.
- `JustificacionService`: registrar, aprobar y rechazar (solo Administrador o RRHH). Al aprobar, la jornada queda como Justificado.
- `ReporteService`: resumen de asistencia, incidencias diarias y datos de los 3 gráficos.
- `Validador`, `Sesion`, `Roles`, `Estados`: ayudas pequeñas. Las claves se guardan cifradas (SHA256).
- Al abrir el programa se crean 90 días de historial de ejemplo para ENF001 y EME001, para que los reportes y gráficos ya muestren datos.

