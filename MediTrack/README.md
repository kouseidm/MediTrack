# MediTrack – Sistema de control de asistencia del personal (BASE)

Proyecto Windows Forms (C#, .NET Framework 4.7.2). Abrir `MediTrack.sln` en Visual Studio y presionar F5.

## Usuarios de prueba
| Usuario | Clave    | Rol              |
|---------|----------|------------------|
| admin   | admin123 | Administrador    |
| rrhh    | rrhh123  | Recursos Humanos |
| lvega   | enf123   | Personal (código ENF001) |
| crojas  | eme123   | Personal (código EME001) |

## Estructura (igual a la del proyecto de referencia)
- `Entities/`      Clases del diagrama (Area, Turno, Personal, RegistroAsistencia, Justificacion, Reportes) + EntidadBase (auditoría).
- `Repositories/`  Acceso a datos: una interfaz y una clase por entidad (`IAreaRepository` / `AreaRepository`, etc.) sobre un `RepositorioMemoria<T>` genérico. Aquí viven las listas; si luego se usa una BD, solo se cambia esta capa.
- `Services/`      Lógica del proyecto, con el mismo estilo del ejercicio multilista (CMatriculaUPC): cada servicio usa su repositorio (`repositorio.Buscar`, `Existe`, `Agregar`, `ObtenerTodos`) y carga los datos iniciales una sola vez. Los métodos devuelven un texto: empieza con "Error: ..." si algo falla, o un mensaje de éxito.
- `Forms/`         Pantallas: Login, Menú, Marcación, Personal, Áreas, Turnos, Jornadas, Justificaciones, Reportes, Gráficos.

## Flujo de prueba
1. Login `rrhh` → "Programar jornadas" → "Programar a todos" (fecha de hoy).
2. Login (botón "Marcar asistencia") → código `ENF001` → Registrar ingreso / salida.
3. "Reportes" → Generar / Ver gráficos.

## Pendiente (no incluido en la base)
Persistencia en BD, exportación de reportes, auditoría con valores anteriores/nuevos, pantalla de cambio de clave propia.

## Formularios con diseño editable (Windows Forms Designer)
Cada pantalla ahora es una `partial class` dividida en dos archivos:
- `FormXxx.Designer.cs` → el **diseño** (controles, posiciones, colores, tamaños). Se edita arrastrando controles en Visual Studio: clic derecho sobre `FormXxx.cs` → *Ver diseñador* (o doble clic).
- `FormXxx.cs` → la **lógica** (eventos, validaciones, llamadas a los Services).

Los eventos de los controles (Click, SelectionChanged, Tick) ya están enlazados desde el diseñador al código existente.
Si agregas un botón nuevo: en el diseñador, doble clic sobre él → crea el método `..._Click` en `FormXxx.cs`.

Notas:
- `Forms/UI.cs` ya no crea controles; solo conserva ayudas (`CargarCombo`, `IdElegido`, `Mostrar`, `IdFilaSeleccionada`).
- Paleta: cabecera `#006978`, botones `#008091`, secundarios gris, peligro rojo, éxito verde. Cámbialos desde la ventana *Propiedades*.
- Las opciones del menú por rol se ocultan en código (`Visible`) pero existen todas en el diseñador.


## Lógica incluida (Services)
- `AreaService`, `TurnoService`, `PersonalService`: registrar, actualizar/modificar, desactivar, listar y buscar. Validan nombres repetidos, códigos de 4 a 10 caracteres y que no se desactive un área o turno con personal activo.
- `AsistenciaService`: programar jornadas (una persona o todos), validar superposición, registrar ingreso y salida, calcular tardanza y horas, y marcar faltas automáticamente.
- `JustificacionService`: registrar, aprobar y rechazar (solo Administrador o RRHH). Al aprobar, la jornada queda como Justificado.
- `ReporteService`: resumen de asistencia, incidencias diarias y datos de los 3 gráficos.
- `Validador`, `Sesion`, `Roles`, `Estados`: ayudas pequeñas. Las claves se guardan cifradas (SHA256).
- Al abrir el programa se crean 90 días de historial de ejemplo para ENF001 y EME001, para que los reportes y gráficos ya muestren datos.
