	Для запуска приложения необходимо Visual Studio 2022, MSSQL Server 2022.
	
1. Установить Visual Studio - https://learn.microsoft.com/ru-ru/visualstudio/install/install-visual-studio?view=vs-2022.

2. Установить MSSQL Server - https://learn.microsoft.com/ru-ru/sql/database-engine/install-windows/install-sql-server?view=sql-server-ver16.

3. В папке проекта RegisterApplications/RegisterApplications/Repositories изменить строку подключения к серверу в файле ApplicationContext.cs.
(Строка 14, необходимо изменить Server=(localdb)\\MSSQLLocalDB; на имя своего установленного сервера)

4. Открыть Package manager console и ввести в нем команду для применения миграций.
(Tools -> NuGet Package Manager -> Package manager console, в открывшемся окне выполнить команду Update-Database.)

5. В обозревателе решений выбрать решение Solution 'RegisterApplications' и выполнить Reduild Solution.

6. Запустить проект.
