using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace SSW.Framework.Data.EF
{
    public class SqlFileDbMigration : DbMigration
    {


        public SqlFileDbMigration()
        {
            
        }


        private string GetUpSql()
        {
            return ReadEmbeddedFile(GetUpFileName());
        }

        private string GetDownSql()
        {
            return ReadEmbeddedFile(GetDownFileName());
        }

        private string GetUpFileName()
        {
            return this.GetType().FullName + ".sql";
        }


        private string GetDownFileName()
        {
            return this.GetType().FullName + "_down.sql";
        }


        private string ReadEmbeddedFile(string name)
        {
            string result = null;
            using (Stream stream =  this.GetType().Assembly.GetManifestResourceStream(name))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }


        public override void Up()
        {
            string sql = GetUpSql();
            if (sql == null) throw new MigrationsException("Failed to find SQL for up migration. SqlFileMigration expects an embedded resource named "+GetUpFileName());
            Sql(sql);
        }



        public override void Down()
        {
            string sql = GetDownSql();
            if (sql == null) throw new MigrationsException("Failed to find SQL for down migration. SqlFileMigration expects an embedded resource named "+GetDownFileName());
            Sql(sql);
        }


    }
}
