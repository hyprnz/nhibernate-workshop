using FluentMigrator;
using System;

namespace Shared.DataAccess.Migrations
{
    [Migration(20201015_1518)]
    public class M20201015_AddDiagnosisTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            const string tableName = "Diagnosis";
            const string templateIdColumn = "TemplateId";

            Create.Table(tableName)
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn(templateIdColumn).AsGuid().NotNullable()
                ;

            Create.Index()
                .OnTable(tableName)
                .OnColumn(templateIdColumn)
                ;
        }
    }
}
