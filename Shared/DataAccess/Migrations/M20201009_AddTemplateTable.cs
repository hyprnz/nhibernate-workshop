using FluentMigrator;
using System;

namespace Shared.DataAccess.Migrations
{
    [Migration(20201009_1511)]
    public class M20201009_AddTemplateTable : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("Template")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable()
                ;
        }
    }
}
