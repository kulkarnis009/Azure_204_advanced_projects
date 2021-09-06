using Microsoft.Azure.Cosmos;
using System;

namespace CosmosDB_Application1
{
    class Program
    {
        public static readonly string _connection_string = "AccountEndpoint=https://az-204-cosmos-db-1.documents.azure.com:443/;AccountKey=dTo0YK9HACihIqsoOPHBcBB9w3kaveqnyvShvMUq3izlJ1lrgeOoDcr9IVpvTdqOh7Q6qjj1wTXXub2szr2fdg==;";
        public static readonly string _database_name = "Az-204_database-2";
        public static readonly string _container_name = "Az-204_container-2";
        public static readonly string _partition_key = "/courseid";

        


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Azure DB services");

            //To create Databse and Container
            //Create_DB_Container create_DB_Container = new Create_DB_Container();
            //create_DB_Container.Create_DB_Container_method();

            //To insert data into Container
            //Insert_data_DB_Container insert_Data_DB_Container = new Insert_data_DB_Container();
            //insert_Data_DB_Container.Insert_data_DB_Container_method();

            //To insert bulk data into container
            //Insert_bulk_data_DB_Container insert_Bulk_Data_DB_Container = new Insert_bulk_data_DB_Container();
            //insert_Bulk_Data_DB_Container.Insert_bulk_data_DB_Container_method();

            //To read data from Container
            //Read_data_DB_Container read_Data_DB_Container = new Read_data_DB_Container();
            //read_Data_DB_Container.Read_data_DB_Container_method();

            //To update data into container
            //Update_data_DB_Container update_Data_DB_Container = new Update_data_DB_Container();
            //update_Data_DB_Container.Update_data_DB_Container_method();

            //To delete data from container
            //Delete_data_DB_Container delete_Data_DB_Container = new Delete_data_DB_Container();
            //delete_Data_DB_Container.Delete_data_DB_Container_method();

            //To call a stored procedure from Cosmos DB
            //Execute_stored_procedure_Cosmos_DB execute_Stored_Procedure_Cosmos_DB = new Execute_stored_procedure_Cosmos_DB();
            //execute_Stored_Procedure_Cosmos_DB.Execute_stored_procedure_Cosmos_DB_method();

            //To add item into CosmosDB using stored procedure
            //Execute_stored_procedure_Additem_Cosmos_DB execute_Stored_Procedure_Additem_Cosmos_DB = new Execute_stored_procedure_Additem_Cosmos_DB();
            //execute_Stored_Procedure_Additem_Cosmos_DB.Execute_stored_procedure_Additem_Cosmos_DB_method();

            //To add timestamp into object using pre-trigger
            //Trigger_item_add_CosmosDB trigger_Item_Add_CosmosDB = new Trigger_item_add_CosmosDB();
            //trigger_Item_Add_CosmosDB.Trigger_item_add_CosmosDB_method();

            Console.ReadKey();
        }
    }
}
