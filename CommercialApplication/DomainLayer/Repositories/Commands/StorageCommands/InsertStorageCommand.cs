﻿using CommercialApplicationCommand.DomainLayer.Entities.StorageEntities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommercialApplication.DomainLayer.Repositories.Commands.StorageCommands
{
    public class InsertStorageCommand : CommandBase, IStorageCommand
    {
        public string StoredFunctionName { get; } = "insert_storage";

        public void Execute(IDbConnection conn, Storage storage, IDbTransaction transaction = null)
        {
            this.connection = (NpgsqlConnection)conn;
            connection.Open();
            NpgsqlCommand command = new NpgsqlCommand(this.StoredFunctionName, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("name", storage.Name);
            command.Parameters.AddWithValue("location", storage.LocationOfStorage);

            // Execute the procedure and obtain a result set
            NpgsqlDataReader dr = command.ExecuteReader();
            connection.Close();
        }
    }
}
