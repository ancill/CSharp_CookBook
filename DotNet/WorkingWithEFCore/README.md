The Northwind class will be used to represent the database. To use EF Core, the class must inherit from DbContext. This class understands how to communicate with databases and dynamically generate SQL statements to query and manipulate data.
Inside your DbContext-derived class, you must define at least one property of the DbSet<T> type. These properties represent the tables. To tell EF Core what columns each table has, the DbSet properties use generics to specify a class that represents a row in the table, with properties that represent its columns.
Your DbContext-derived class should have an overridden method named OnConfiguring, which will set the database connection string.




The two properties that relate the two entities, Category.Products and Product.Category, are both marked as virtual. This allows EF Core to inherit and override the properties to provide extra features, such as lazy loading. Lazy loading is not available in EF Core 2.0 or earlier.
