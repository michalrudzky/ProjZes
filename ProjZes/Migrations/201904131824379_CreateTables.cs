namespace ProjZes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            CreateTable(
                "dbo.Koszyk",
                c => new
                    {
                        KOS_PK_id = c.Int(nullable: false, identity: true),
                        KOS_wartosc = c.Single(nullable: false),
                        US_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KOS_PK_id)
                .ForeignKey("dbo.Usluga", t => t.US_FK_id)
                .Index(t => t.US_FK_id);
            
            CreateTable(
                "dbo.Usluga",
                c => new
                    {
                        US_PK_id = c.Int(nullable: false, identity: true),
                        TAN_FK_id = c.Int(nullable: false),
                        REZ_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.US_PK_id)
                .ForeignKey("dbo.Tankowanie", t => t.TAN_FK_id)
                .ForeignKey("dbo.Rezerwacja", t => t.REZ_FK_id)
                .Index(t => t.TAN_FK_id)
                .Index(t => t.REZ_FK_id);
            
            CreateTable(
                "dbo.Tankowanie",
                c => new
                    {
                        TAN_PK_id = c.Int(nullable: false, identity: true),
                        TAN_ilosc = c.Single(nullable: false),
                        TAN_data = c.DateTime(nullable: false),
                        TAN_wartosc = c.Single(nullable: false),
                        PAL_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TAN_PK_id)
                .ForeignKey("dbo.Paliwo", t => t.PAL_FK_id)
                .Index(t => t.PAL_FK_id);
            
            CreateTable(
                "dbo.Paliwo",
                c => new
                    {
                        PAL_PK_id = c.Int(nullable: false, identity: true),
                        PAL_rodzaj = c.String(nullable: false),
                        PAL_cena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PAL_PK_id);
            
            CreateTable(
                "dbo.Rezerwacja",
                c => new
                    {
                        REZ_PK_id = c.Int(nullable: false, identity: true),
                        REZ_data = c.DateTime(nullable: false),
                        REZ_czas = c.Time(nullable: false, precision: 7),
                        KL_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.REZ_PK_id)
                .ForeignKey("dbo.Klient", t => t.KL_FK_id)
                .Index(t => t.KL_FK_id);
            
            CreateTable(
                "dbo.Klient",
                c => new
                    {
                        KL_PK_id = c.Int(nullable: false, identity: true),
                        KL_nr = c.Int(nullable: false),
                        KL_nip = c.Long(nullable: false),
                        UZ_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KL_PK_id)
                .ForeignKey("dbo.Uzytkownik", t => t.UZ_FK_id)
                .Index(t => t.UZ_FK_id);
            
            CreateTable(
                "dbo.Uzytkownik",
                c => new
                    {
                        UZ_PK_id = c.Int(nullable: false, identity: true),
                        UZ_imie = c.String(nullable: false, maxLength: 20),
                        UZ_nazwisko = c.String(nullable: false, maxLength: 20),
                        UZ_adres = c.String(nullable: false, maxLength: 20),
                        UZ_nr_tel = c.Int(nullable: false),
                        UZ_email = c.String(nullable: false, maxLength: 20),
                        UZ_haslo = c.String(nullable: false, maxLength: 20),
                        UZ_punkty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UZ_PK_id);
            
            CreateTable(
                "dbo.Myjnia",
                c => new
                    {
                        MYJ_PK_id = c.Int(nullable: false, identity: true),
                        MYJ_uslugi = c.String(nullable: false, maxLength: 20),
                        MYJ_czas = c.Time(nullable: false, precision: 7),
                        MYJ_cena = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.MYJ_PK_id);
            
            CreateTable(
                "dbo.TL_Rezerwacja_Myjni",
                c => new
                    {
                        MRE_PK_id = c.Int(nullable: false, identity: true),
                        MYJ_FK_id = c.Int(nullable: false),
                        REZ_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MRE_PK_id);
            
            CreateTable(
                "dbo.Znizka",
                c => new
                    {
                        ZN_PK_id = c.Int(nullable: false, identity: true),
                        ZN_nazwa = c.String(nullable: false, maxLength: 20),
                        ZN_wartosc = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZN_PK_id);
            
            CreateTable(
                "dbo.Tl_Uprawnienia_Pracownikow",
                c => new
                    {
                        UPP_PK_id = c.Int(nullable: false, identity: true),
                        PR_FK_id = c.Int(nullable: false),
                        UPR_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UPP_PK_id);
            
            CreateTable(
                "dbo.Pracownik",
                c => new
                    {
                        PR_PK_id = c.Int(nullable: false, identity: true),
                        PR_pensja = c.Single(nullable: false),
                        PR_nr_konta = c.Long(nullable: false),
                        PR_liczba_godzin = c.Single(nullable: false),
                        UZ_FK_id = c.Int(nullable: false),
                        UPR_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PR_PK_id)
                .ForeignKey("dbo.Uprawnienia", t => t.UPR_FK_id)
                .ForeignKey("dbo.Uzytkownik", t => t.UZ_FK_id)
                .Index(t => t.UZ_FK_id)
                .Index(t => t.UPR_FK_id);
            
            CreateTable(
                "dbo.Uprawnienia",
                c => new
                    {
                        UPR_PK_id = c.Int(nullable: false, identity: true),
                        UPR_uprawnienia = c.String(),
                    })
                .PrimaryKey(t => t.UPR_PK_id);
            
            CreateTable(
                "dbo.Zbiornik",
                c => new
                    {
                        ZB_PK_id = c.Int(nullable: false, identity: true),
                        ZB_stan = c.Single(nullable: false),
                        PAL_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ZB_PK_id)
                .ForeignKey("dbo.Paliwo", t => t.PAL_FK_id)
                .Index(t => t.PAL_FK_id);
            
            CreateTable(
                "dbo.TL_Znizka",
                c => new
                    {
                        TRZ_PK_id = c.Int(nullable: false, identity: true),
                        ZN_FK_id = c.Int(nullable: false),
                        TR_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TRZ_PK_id);
            
            CreateTable(
                "dbo.Transakcja",
                c => new
                    {
                        TR_PK_id = c.Int(nullable: false, identity: true),
                        TR_data = c.DateTime(nullable: false),
                        TR_wartosc = c.Single(nullable: false),
                        KOS_FK_id = c.Int(nullable: false),
                        PR_FK_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TR_PK_id)
                .ForeignKey("dbo.Koszyk", t => t.KOS_FK_id)
                .ForeignKey("dbo.Pracownik", t => t.PR_FK_id)
                .Index(t => t.KOS_FK_id)
                .Index(t => t.PR_FK_id);
            
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Transakcja", "PR_FK_id", "dbo.Pracownik");
            DropForeignKey("dbo.Transakcja", "KOS_FK_id", "dbo.Koszyk");
            DropForeignKey("dbo.Zbiornik", "PAL_FK_id", "dbo.Paliwo");
            DropForeignKey("dbo.Pracownik", "UZ_FK_id", "dbo.Uzytkownik");
            DropForeignKey("dbo.Pracownik", "UPR_FK_id", "dbo.Uprawnienia");
            DropForeignKey("dbo.Koszyk", "US_FK_id", "dbo.Usluga");
            DropForeignKey("dbo.Usluga", "REZ_FK_id", "dbo.Rezerwacja");
            DropForeignKey("dbo.Rezerwacja", "KL_FK_id", "dbo.Klient");
            DropForeignKey("dbo.Klient", "UZ_FK_id", "dbo.Uzytkownik");
            DropForeignKey("dbo.Usluga", "TAN_FK_id", "dbo.Tankowanie");
            DropForeignKey("dbo.Tankowanie", "PAL_FK_id", "dbo.Paliwo");
            DropIndex("dbo.Transakcja", new[] { "PR_FK_id" });
            DropIndex("dbo.Transakcja", new[] { "KOS_FK_id" });
            DropIndex("dbo.Zbiornik", new[] { "PAL_FK_id" });
            DropIndex("dbo.Pracownik", new[] { "UPR_FK_id" });
            DropIndex("dbo.Pracownik", new[] { "UZ_FK_id" });
            DropIndex("dbo.Klient", new[] { "UZ_FK_id" });
            DropIndex("dbo.Rezerwacja", new[] { "KL_FK_id" });
            DropIndex("dbo.Tankowanie", new[] { "PAL_FK_id" });
            DropIndex("dbo.Usluga", new[] { "REZ_FK_id" });
            DropIndex("dbo.Usluga", new[] { "TAN_FK_id" });
            DropIndex("dbo.Koszyk", new[] { "US_FK_id" });
            DropTable("dbo.Transakcja");
            DropTable("dbo.TL_Znizka");
            DropTable("dbo.Zbiornik");
            DropTable("dbo.Uprawnienia");
            DropTable("dbo.Pracownik");
            DropTable("dbo.Tl_Uprawnienia_Pracownikow");
            DropTable("dbo.Znizka");
            DropTable("dbo.TL_Rezerwacja_Myjni");
            DropTable("dbo.Myjnia");
            DropTable("dbo.Uzytkownik");
            DropTable("dbo.Klient");
            DropTable("dbo.Rezerwacja");
            DropTable("dbo.Paliwo");
            DropTable("dbo.Tankowanie");
            DropTable("dbo.Usluga");
            DropTable("dbo.Koszyk");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
