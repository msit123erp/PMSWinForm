CREATE TABLE [dbo].[SupplierInfo] (
    [SupplierInfoOID]   INT            IDENTITY (1, 1) NOT NULL,
    [SupplierCode]      NVARCHAR (6)   NOT NULL,
    [SupplierName]      NVARCHAR (30)  NOT NULL,
    [TaxID]             VARCHAR (10)   NOT NULL,
    [Email]             VARCHAR (64)   NOT NULL,
    [Tel]               VARCHAR (30)   NOT NULL,
    [Address]           NVARCHAR (256) NOT NULL,
    [SupplierRatingOID] INT            NULL,
    CONSTRAINT [PK_SupplierInfo] PRIMARY KEY CLUSTERED ([SupplierCode] ASC),
    CONSTRAINT [FK_SupplierInfo_SupplierRating] FOREIGN KEY ([SupplierRatingOID]) REFERENCES [dbo].[SupplierRating] ([SupplierRatingOID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商資料', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商資料識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'SupplierInfoOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商代碼
PK
1碼字母+5碼數字
DF:''S''
SP UPDATE:S+5碼識別碼
P:廠商，S:供應商', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'SupplierCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'SupplierName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'統編', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'TaxID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'電子信箱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'Email';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'市話', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'Tel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'Address';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商等級識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierInfo', @level2type = N'COLUMN', @level2name = N'SupplierRatingOID';

