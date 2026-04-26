---

# CLASE: DESARROLLO WEB CON C# + ASP.NET MVC + EF CORE + MYSQL

## 1. Fundamento: C# como lenguaje base

Antes de cualquier framework, todo parte de C#.

### Conceptos clave

* Tipado fuerte: cada variable tiene un tipo definido
* Clases como representación de entidades
* Propiedades como acceso controlado a datos

Ejemplo conceptual:

```csharp
public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
}
```

Esto no es solo código: es una **abstracción de una tabla**.

---

## 2. Modelado de dominio (OOP aplicado)

Aquí defines el “mundo” de tu sistema.

En tu caso:

* User → persona
* Book → recurso
* Loan → relación (evento de préstamo)

### Concepto importante

No todo es una entidad simple:

* `Loan` no es solo una tabla, es una **relación con lógica**

Ejemplo:

```csharp
public class Loan
{
    public int UserId { get; set; }
    public User User { get; set; }
}
```

Esto implica:

* Relación en memoria
* Relación en base de datos

---

## 3. Arquitectura MVC (estructura del sistema)

El patrón que organiza todo.

### Model

Representa datos y reglas:

* Clases (`User`, `Book`)
* DbContext

### View

Interfaz:

* HTML + Razor
* Renderiza datos

### Controller

Intermediario:

* Recibe solicitudes
* Procesa lógica
* Devuelve respuestas

Flujo real:

```
Usuario → Controller → DbContext → Base de datos → Controller → View → Usuario
```

---

## 4. Razor (motor de vistas)

Permite mezclar C# con HTML.

### Ejemplo:

```html
@model List<Book>

@foreach (var book in Model)
{
    <p>@book.Title</p>
}
```

### Conceptos clave:

* Tipado fuerte en vistas
* Render dinámico
* Separación de lógica y presentación

---

## 5. Entity Framework Core (ORM)

Traduce C# ↔ SQL automáticamente.

### Elementos principales

#### DbContext

```csharp
public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
}
```

#### DbSet

Representa tablas:

* `Users`
* `Books`
* `Loans`

---

## 6. Configuración de relaciones

Se hace en `OnModelCreating`.

### Ejemplo de tu caso:

```csharp
modelBuilder.Entity<Loan>()
    .HasOne(l => l.User)
    .WithMany(u => u.Loans)
    .HasForeignKey(l => l.UserId);
```

### Esto define:

* 1 usuario → muchos préstamos
* clave foránea en DB

---

## 7. Restricciones e integridad

Aquí pasas de “funciona” a “bien diseñado”.

### Tipos que usas:

#### Cascade

```csharp
OnDelete(DeleteBehavior.Cascade)
```

Si borras usuario → borra préstamos

#### Restrict

```csharp
OnDelete(DeleteBehavior.Restrict)
```

No puedes borrar libro si está en uso

#### Unique

```csharp
HasIndex(l => new { l.UserId, l.BookId }).IsUnique();
```

Evita duplicados

---

## 8. Base de datos (MySQL)

Tu modelo se traduce a SQL.

### Ejemplo real:

```sql
foreign key (user_id) references users(id)
```

### Conceptos clave:

* Claves primarias
* Claves foráneas
* Integridad referencial
* Constraints

---

## 9. CRUD completo

Operaciones básicas:

* Create → insertar
* Read → consultar
* Update → modificar
* Delete → eliminar

### Flujo típico:

```csharp
_context.Users.Add(user);
_context.SaveChanges();
```

EF genera el SQL automáticamente.

---

## 10. LINQ (consulta en C#)

Permite consultar datos sin escribir SQL.

### Ejemplo:

```csharp
var users = _context.Users
    .Where(u => u.Name.Contains("Alice"))
    .ToList();
```

Esto se convierte internamente en SQL.

---

## 11. Lógica de negocio

Aquí el sistema deja de ser solo CRUD.

Ejemplo en tu proyecto:

* Si prestas un libro:

  * `available = false`
* Si se devuelve:

  * `available = true`

Esto no lo maneja la base de datos automáticamente → lo defines tú.

---

## 12. Validación y errores

Problemas típicos:

* Nulls (`DBNull`)
* Violación de constraints
* Datos inválidos

Soluciones:

* Validaciones en modelos
* Control de excepciones

---

## 13. Capa visual (UI)

Incluye:

* HTML
* CSS (`wwwroot/css`)
* Layout (`_Layout.cshtml`)
* Bootstrap

### Concepto clave:

La UI depende de:

* Modelos
* Datos enviados por el Controller

---

# CONEXIÓN GENERAL (lo más importante entender)

Todo el sistema funciona así:

1. Defines clases en C#
2. EF las convierte en tablas
3. Controllers usan esas clases
4. Views muestran los datos
5. Usuario interactúa
6. EF traduce acciones a SQL

---

# CONCLUSIÓN

* Modelos → DB
* Controller → lógica
* View → presentación
* EF → puente

---
