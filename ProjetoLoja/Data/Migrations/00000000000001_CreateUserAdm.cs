using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoLoja.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("00000000000001_CreateUserAdm")]
    public partial class CreateUserAdm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO AspNetRoles(Id, ConcurrencyStamp, [Name], NormalizedName) VALUES ('683869B7-1E64-4DB5-B2D4-6FB1E9BDCD6F', NULL, 'ADM','ADM')");

            //email: admin@admin.com
            //password: adM123!@#
            migrationBuilder.Sql(@"INSERT INTO AspNetUsers(Id, AccessFailedCount, ConcurrencyStamp, Email, EmailConfirmed, LockoutEnabled, LockoutEnd, NormalizedEmail, NormalizedUserName,
                                 PasswordHash, PhoneNumber, PhoneNumberConfirmed, SecurityStamp, TwoFactorEnabled, UserName) VALUES ('c490ef14-f6d5-413a-a322-730f077ece90', 0,
                                 'a4b23f0d-2277-43bb-b45e-d73a6b679be2', 'admin@admin.com', 0, 1, null, 'ADMIN@ADMIN.COM','ADMIN@ADMIN.COM', 'AQAAAAEAACcQAAAAEKlYfQGNMTEwhnIziQNuOAgCOs0aeG6LBCzFvC/JWbqV6ypgtXfWR5AECfIqSPUtUQ==',
                                 null, 0, 'c333d704-86a1-4264-bae1-3718d678f2af',0,'admin@admin.com')");

            migrationBuilder.Sql(@"INSERT INTO AspNetUserRoles(UserId, RoleId) VALUES ('c490ef14-f6d5-413a-a322-730f077ece90','683869B7-1E64-4DB5-B2D4-6FB1E9BDCD6F')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
