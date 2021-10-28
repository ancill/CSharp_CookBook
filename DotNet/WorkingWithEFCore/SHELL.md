# Console commands

check if you have already installed dotnet-ef as a global tool,
    dotnet tool list --global

version is already installed, then uninstall the tool, as shown in the following command:
    dotnet tool uninstall --global dotnet-ef

Install the latest version, as shown in the following command:
    dotnet tool install --global dotnet-ef --version 5.0.0

More Information: There are many other conventions, and you can even define your own, but that is beyond the scope of this book. You can read about them at the following link: https://docs.microsoft.com/en-us/ef/core/ modeling/


Scaffolding is the process of using a tool to create classes that represent the model of an
existing database using reverse engineering. A good scaffolding tool allows you to extend the automatically generated classes and then regenerate those classes without losing your extended classes.

        dotnet add package Microsoft.EntityFrameworkCore.Design

        dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.
        EntityFrameworkCore.Sqlite --table Categories --table Products --output-
        dir AutoGenModels --namespace Packt.Shared.AutoGen --data-annotations
        --context Northwind

Note the following:
• The command to perform: dbcontext scaffold
• The connection string: "Filename=Northwind.db"
• The database provider: Microsoft.EntityFrameworkCore.Sqlite
• The tables to generate models for: --table Categories --table Products
• The output folder: --output-dir AutoGenModels
• The namespace: --namespace Packt.Shared.AutoGen
• To use data annotations as well as Fluent API: --data-annotations
• To rename the context from [database_name]Context: --context Northwind
