CREATE TABLE [dbo].[SupplierAccount] (
    [SupplierAccountOID] INT            IDENTITY (1, 1) NOT NULL,
    [SupplierAccountID]  VARCHAR (10)   NOT NULL,
    [PasswordHash]       VARCHAR (128)  NOT NULL,
    [PasswordSalt]       VARCHAR (68)   NOT NULL,
    [ContactName]        NVARCHAR (30)  NOT NULL,
    [Email]              NVARCHAR (64)  NOT NULL,
    [Address]            NVARCHAR (256) NULL,
    [Mobile]             VARCHAR (30)   NULL,
    [Tel]                VARCHAR (30)   NULL,
    [SupplierCode]       NVARCHAR (6)   NOT NULL,
    [AccountStatus]      VARCHAR (1)    NOT NULL,
    [CreateDate]         DATETIME       NOT NULL,
    [CreatorEmployeeID]  VARCHAR (10)   NOT NULL,
    [ModifiedDate]       DATETIME       NULL,
    [SASendLetterState]  VARCHAR (1)    NULL,
    [SASendLetterDate]   DATETIME       NULL,
    CONSTRAINT [PK_SupplierAccount] PRIMARY KEY CLUSTERED ([SupplierAccountID] ASC),
    CONSTRAINT [FK_SupplierAccount_Buyer] FOREIGN KEY ([CreatorEmployeeID]) REFERENCES [dbo].[Buyer] ([EmployeeID]),
    CONSTRAINT [FK_SupplierAccount_Employee] FOREIGN KEY ([CreatorEmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [FK_SupplierAccount_SupplierInfo] FOREIGN KEY ([SupplierCode]) REFERENCES [dbo].[SupplierInfo] ([SupplierCode])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商帳號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商帳號識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'SupplierAccountOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商帳號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'SupplierAccountID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'密碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'PasswordHash';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'密碼鹽', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'PasswordSalt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'聯絡人', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'ContactName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'電子信箱', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'Email';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'Address';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'手機', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'Mobile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'市話', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'Tel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'SupplierCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'帳號狀態
R 重設 D 停用 E 啟用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'AccountStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'新增日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'建立者員工編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'CreatorEmployeeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'ModifiedDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'發信狀態
Y / N / S 
成功 / 失敗 / 發信中', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'SASendLetterState';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'發信時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SupplierAccount', @level2type = N'COLUMN', @level2name = N'SASendLetterDate';

