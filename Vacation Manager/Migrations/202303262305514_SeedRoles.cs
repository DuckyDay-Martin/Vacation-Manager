using Microsoft.EntityFrameworkCore.Migrations;

namespace Vacation_Manager.Migrations
{
    public partial class SeedRoles : Migration
    {
        private string CEORoleId = Guid.NewGuid().ToString();
        private string DeveloperRoleId = Guid.NewGuid().ToString();
        private string TeamLeadId = Guid.NewGuid().ToString();

        private string User1Id = Guid.NewGuid().ToString();
        private string User2Id = Guid.NewGuid().ToString();

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUser(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO `YourDataBaseName`.`AspNetRoles` (`Id`,`Name`,`NormalizedName`,`ConcurrencyStamp`)
            VALUES ('{CEORoleId}', 'CEO', 'CEO', null);");
            migrationBuilder.Sql(@$"INSERT INTO `YourDataBaseName`.`AspNetRoles` (`Id`,`Name`,`NormalizedName`,`ConcurrencyStamp`)
            VALUES ('{DeveloperRoleId}', 'Developer', 'DEVELOPER', null);");
            migrationBuilder.Sql(@$"INSERT INTO `YourDataBaseName`.`AspNetRoles` (`Id`,`Name`,`NormalizedName`,`ConcurrencyStamp`)
            VALUES ('{TeamLeadId}', 'TeamLead', 'TEAMLEAD', null);");
        }

        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @$"INSERT `YourDataBaseName`.`AspNetUsers` (`Id`,`FirstName`, `LastName`, `UserName`, `NormalizedUserName`, 
                `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, 
                `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) 
                VALUES 
                (N'{User1Id}', N'Test 2', N'Lastname', N'test2@test.ca', N'TEST2@TEST.CA', 
                N'test2@test.ca', N'TEST2@TEST.CA', 0, 
                N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
                N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");

            migrationBuilder.Sql(
                @$"INSERT `YourDataBaseName`.`AspNetUsers` (`Id`, `FirstName`, `LastName`, `UserName`, `NormalizedUserName`, 
                `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, 
                `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`) 
                VALUES 
                (N'{User2Id}', N'Test 3', N'Lastname', N'test3@test.ca', N'TEST3@TEST.CA', 
                N'test3@test.ca', N'TEST3@TEST.CA', 0, 
                N'AQAAAAEAACcQAAAAEDGQ5wwj6Iz0lXHIZ5IwuvgSO88jrSBT1etWcDYjJN5CBNDKvddZcEeixYBYmcdFag==', 
                N'YUPAFWNGZI2UC5FOITC7PX5J7XZTAZAA', N'8e150555-a20d-4610-93ff-49c5af44f749', NULL, 0, 0, NULL, 1, 0)");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO `YourDataBaseName`.`AspNetUserRoles`
           (`UserId`
           ,`RoleId`)
        VALUES
           ('{User1Id}', '{DeveloperRoleId}');");


            migrationBuilder.Sql(@$"
        INSERT INTO `YourDataBaseName`.`AspNetUserRoles`
           (`UserId`
           ,`RoleId`)
        VALUES
           ('{User2Id}', '{CEORoleId}');");

        }
    }
}
