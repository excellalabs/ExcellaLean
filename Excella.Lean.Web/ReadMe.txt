- Create a ConnectionStrings.config file in the Web project folder, do not add it to the project. 
This will never get committed to your repository, which will allow every developer to have their own data stores.

Sample for the boilerplate:
<connectionStrings>
 <add name="LeanEntities" connectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\ExcellaLean.mdf;Integrated Security=True" providerName="System.Data.SqlClient" />
</connectionStrings>

- Enable Windows Authentication in IIS, disable Anonymous Authentication

- Make sure URL has a trailing slash: e.g. http://localhost/ExcellaLean/