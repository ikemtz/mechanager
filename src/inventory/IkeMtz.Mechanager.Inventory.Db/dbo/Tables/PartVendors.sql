CREATE TABLE [dbo].[PartVendors] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [PartId]       UNIQUEIDENTIFIER   NOT NULL,
    [VendorId]     UNIQUEIDENTIFIER   NOT NULL,
    [Barcode]      VARCHAR (50)       NOT NULL,
    [Cost]         MONEY              NOT NULL,
    [TenantId]     CHAR (4)           NOT NULL,
    [CreatedBy]    NVARCHAR (250)     NOT NULL,
    [UpdatedBy]    NVARCHAR (250)     NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) CONSTRAINT [DF_PartVendors_CreatedOnUtc] DEFAULT (getutcdate()) NOT NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_PartVendors] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_PartVendors_Parts] FOREIGN KEY ([PartId]) REFERENCES [dbo].[Parts] ([Id]),
    CONSTRAINT [FK_PartVendors_Vendors] FOREIGN KEY ([VendorId]) REFERENCES [dbo].[Vendors] ([Id])
);

