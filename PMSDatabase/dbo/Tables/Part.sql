CREATE TABLE [dbo].[Part] (
    [PartOID]            INT            IDENTITY (1, 1) NOT NULL,
    [PartNumber]         NVARCHAR (10)  NOT NULL,
    [PartName]           NVARCHAR (30)  NOT NULL,
    [PartSpec]           NVARCHAR (30)  NULL,
    [SupplierCode]       NVARCHAR (6)   NOT NULL,
    [PartUnitOID]        INT            NOT NULL,
    [UnitPrice]          INT            NULL,
    [CreatedDate]        DATETIME       NOT NULL,
    [PictureAdress]      NVARCHAR (256) NULL,
    [PictureDescription] NVARCHAR (256) NULL,
    CONSTRAINT [PK_Part] PRIMARY KEY CLUSTERED ([PartNumber] ASC),
    CONSTRAINT [FK_Part_PartUnit] FOREIGN KEY ([PartUnitOID]) REFERENCES [dbo].[PartUnit] ([PartUnitOID]),
    CONSTRAINT [FK_Part_SupplierInfo] FOREIGN KEY ([SupplierCode]) REFERENCES [dbo].[SupplierInfo] ([SupplierCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件總表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件總表識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'PartOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'PartNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件品名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'PartName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件規格', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'PartSpec';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'SupplierCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'單位識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'PartUnitOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'單價', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'UnitPrice';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件建檔時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'CreatedDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'圖片位址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'PictureAdress';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'圖片說明', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Part', @level2type = N'COLUMN', @level2name = N'PictureDescription';

