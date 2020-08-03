CREATE TABLE [dbo].[Transactions] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [PartId]       UNIQUEIDENTIFIER   NOT NULL,
    [VendorId] UNIQUEIDENTIFIER   NULL,
    [PartVendorId] UNIQUEIDENTIFIER   NULL,
    [Amount]       DECIMAL (18)       NOT NULL,
    [StoreId]      UNIQUEIDENTIFIER   NOT NULL,
    [CreatedBy]    NVARCHAR (250)     NOT NULL,
    [UpdatedBy]    NVARCHAR (250)     NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) CONSTRAINT [DF_Transactions_CreatedOnUtc] DEFAULT (getutcdate()) NOT NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_Parts] FOREIGN KEY ([PartId]) REFERENCES [dbo].[Parts] ([Id]),
    CONSTRAINT [FK_Transactions_PartVendors] FOREIGN KEY ([PartVendorId]) REFERENCES [dbo].[PartVendors] ([Id])
);

