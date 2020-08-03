CREATE TABLE [dbo].[Vendors] (
    [Id]           UNIQUEIDENTIFIER   NOT NULL,
    [Name]         NVARCHAR (50)      NOT NULL,
    [TenantId]     CHAR (4)           NOT NULL,
    [CreatedBy]    NVARCHAR (250)     NOT NULL,
    [UpdatedBy]    NVARCHAR (250)     NULL,
    [CreatedOnUtc] DATETIMEOFFSET (7) CONSTRAINT [DF_Vendors_CreatedOnUtc] DEFAULT (getutcdate()) NOT NULL,
    [UpdatedOnUtc] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Vendors] PRIMARY KEY CLUSTERED ([Id] ASC)
);

