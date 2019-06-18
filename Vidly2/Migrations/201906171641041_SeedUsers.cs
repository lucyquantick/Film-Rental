namespace Vidly2.Migrations
{
		using System;
		using System.Data.Entity.Migrations;
		
		public partial class SeedUsers : DbMigration
		{
				public override void Up()
				{
			Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'10263bb5-b492-4c5e-a4fe-119f3484f161', N'guest@vidly.com', 0, N'APlC/8pb/PAdxrTHEDHaImyuNhVfJrhzn1IKuS7fKNAUg5Bj2pSCYi6ljBlKecT9rw==', N'0b01936e-5be1-475d-9262-c31219f96625', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'659fd303-63ef-4308-832c-2a919224b678', N'lucyquantick@gmail.com', 0, N'AI8K+klJfnzLaxigmOWoEW+L36vB0a/1PBgqU1Z4Vu3/DUZ+5+6Vy/NcXfrO2ytGJg==', N'92dc32d8-6add-4950-af3f-533633b8c3a9', NULL, 0, 0, NULL, 1, 0, N'lucyquantick@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fad98551-2228-4d84-8621-01a3010da40e', N'admin@vidly.com', 0, N'AI8syFIzHEt4i9AXuW8/q99WmlDH9TLAhVBOju4YPbAeI/xO3Kh3X3vFJM0MsBsq9A==', N'13a2e914-1c1d-416c-9046-d8ae5c225707', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f9c8644b-4167-4a01-8d41-7f510974d635', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fad98551-2228-4d84-8621-01a3010da40e', N'f9c8644b-4167-4a01-8d41-7f510974d635')

");
				}
				
				public override void Down()
				{
				}
		}
}
