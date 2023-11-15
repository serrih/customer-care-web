# Ticket de atención al cliente

Este proyecto es un sistema WEB para atención al cliente, donde se tiene un pequeño formulario para registrar Id y nombre de la persona que desea ser atendida y dos colas de
atención al cliente.

Cada cola, tiene un tiempo fijo de atención a cada cliente. La cola 1, tiene una duración de 2 min, mientras que la cola 2 tiene una duración de 3 min.
Se deben implementar las siguientes acciones:
- En cada registro de persona, el sistema debe decidir en cuál de las colas será atendido con mayor rapidez y asignarlo a dicha cola.
- Se requiere guardar en base de datos la información de las colas, de manera de poder recuperarla al momento de abrir la aplicación.
- Al recuperar data de la base de datos, se debe hacer la verificación de las personas que estaban en la cola y eliminar aquellas que ya fueron atendidas.
