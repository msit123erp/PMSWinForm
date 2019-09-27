CREATE TABLE [dbo].[CompanyInfo] (
    [CompanyInfoOID] INT            IDENTITY (1, 1) NOT NULL,
    [CompanyCode]    NVARCHAR (6)   NOT NULL,
    [CompanyName]    NVARCHAR (30)  NOT NULL,
    [TaxID]          VARCHAR (10)   NOT NULL,
    [Email]          VARCHAR (64)   NOT NULL,
    [Tel]            VARCHAR (30)   NOT NULL,
    [Address]        NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_CompanyInfo] PRIMARY KEY CLUSTERED ([CompanyCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司基本資料', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司基本資料識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo', @level2type = N'COLUMN', @level2name = N'CompanyInfoOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo', @level2type = N'COLUMN', @level2name = N'CompanyCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'公司名稱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo', @level2type = N'COLUMN', @level2name = N'CompanyName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'統編', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo', @level2type = N'COLUMN', @level2name = N'TaxID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'電子信箱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo', @level2type = N'COLUMN', @level2name = N'Email';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'市話', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo', @level2type = N'COLUMN', @level2name = N'Tel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'CompanyInfo', @level2type = N'COLUMN', @level2name = N'Address';

