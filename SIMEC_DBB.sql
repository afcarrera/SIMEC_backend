/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2014                    */
/* Created on:     04/07/2021 23:37:04                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLEFACTURA') and o.name = 'FK_DETALLEF_RELATIONS_FACTURA')
alter table DETALLEFACTURA
   drop constraint FK_DETALLEF_RELATIONS_FACTURA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('DETALLEFACTURA') and o.name = 'FK_DETALLEF_RELATIONS_PRODUCTO')
alter table DETALLEFACTURA
   drop constraint FK_DETALLEF_RELATIONS_PRODUCTO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FACTURA') and o.name = 'FK_FACTURA_RELATIONS_CLIENTE')
alter table FACTURA
   drop constraint FK_FACTURA_RELATIONS_CLIENTE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CLIENTE')
            and   type = 'U')
   drop table CLIENTE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLEFACTURA')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLEFACTURA.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('DETALLEFACTURA')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index DETALLEFACTURA.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DETALLEFACTURA')
            and   type = 'U')
   drop table DETALLEFACTURA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FACTURA')
            and   name  = 'RELATIONSHIP_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index FACTURA.RELATIONSHIP_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FACTURA')
            and   type = 'U')
   drop table FACTURA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTO')
            and   type = 'U')
   drop table PRODUCTO
go

/*==============================================================*/
/* Table: CLIENTE                                               */
/*==============================================================*/
create table CLIENTE (
   IDCLIENTE            varchar(16)          not null,
   NOMBRECOMPLETO       varchar(128)         null,
   ESTADO               bit                  null,
   constraint PK_CLIENTE primary key (IDCLIENTE)
)
go

/*==============================================================*/
/* Table: DETALLEFACTURA                                        */
/*==============================================================*/
create table DETALLEFACTURA (
   IDDETALLE            int                  identity,
   IDPRODUCTO           int                  not null,
   IDFACTURA            int                  not null,
   CANTIDAD             float                null,
   SUBTOTAL             float                null,
   constraint PK_DETALLEFACTURA primary key nonclustered (IDDETALLE)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/




create nonclustered index RELATIONSHIP_2_FK on DETALLEFACTURA (IDPRODUCTO ASC)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/




create nonclustered index RELATIONSHIP_3_FK on DETALLEFACTURA (IDFACTURA ASC)
go

/*==============================================================*/
/* Table: FACTURA                                               */
/*==============================================================*/
create table FACTURA (
   IDFACTURA            int                  identity,
   IDCLIENTE            varchar(16)          not null,
   FECHA                datetime             null,
   TOTAL                float                null,
   constraint PK_FACTURA primary key (IDFACTURA)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/




create nonclustered index RELATIONSHIP_1_FK on FACTURA (IDCLIENTE ASC)
go

/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO (
   IDPRODUCTO           int                  identity,
   DESCRIPCION          varchar(128)         null,
   constraint PK_PRODUCTO primary key (IDPRODUCTO)
)
go

alter table DETALLEFACTURA
   add constraint FK_DETALLEF_RELATIONS_FACTURA foreign key (IDFACTURA)
      references FACTURA (IDFACTURA)
go

alter table DETALLEFACTURA
   add constraint FK_DETALLEF_RELATIONS_PRODUCTO foreign key (IDPRODUCTO)
      references PRODUCTO (IDPRODUCTO)
go

alter table FACTURA
   add constraint FK_FACTURA_RELATIONS_CLIENTE foreign key (IDCLIENTE)
      references CLIENTE (IDCLIENTE)
go

