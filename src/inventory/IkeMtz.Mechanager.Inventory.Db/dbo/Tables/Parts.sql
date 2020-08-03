CREATE TABLE [dbo].[Parts] (
    [Id]              UNIQUEIDENTIFIER   NOT NULL,
    [ManufacturerId]  NVARCHAR (25)      NOT NULL,
    [Description]     NVARCHAR (250)     NOT NULL,
    [Location]        NVARCHAR (5)       NOT NULL,
    [Price]           MONEY              NULL,
    [CurrentQuantity] DECIMAL (18)       CONSTRAINT [DF_Parts_CurrentQuantity] DEFAULT ((0)) NOT NULL,
    [MinThreshold]    DECIMAL (18)       CONSTRAINT [DF_Parts_MinThreshold] DEFAULT ((1)) NOT NULL,
    [ReplenishAmount] DECIMAL (18)       CONSTRAINT [DF_Parts_ReplenishAmount] DEFAULT ((1)) NOT NULL,
    [LastSold]        DATETIMEOFFSET (7) NULL,
    [StoreId]         UNIQUEIDENTIFIER   NOT NULL,
    [IsEnabled]       BIT                CONSTRAINT [DF_Parts_IsEnabled] DEFAULT ((1)) NOT NULL,
    [TenantId]        CHAR (4)           NOT NULL,
    [CreatedBy]       NVARCHAR (250)     NOT NULL,
    [UpdatedBy]       NVARCHAR (250)     NULL,
    [CreatedOnUtc]    DATETIMEOFFSET (7) CONSTRAINT [DF__Parts__CreatedOn__38996AB5] DEFAULT (getutcdate()) NOT NULL,
    [UpdatedOnUtc]    DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Parts] PRIMARY KEY CLUSTERED ([Id] ASC)
);

