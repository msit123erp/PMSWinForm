CREATE TABLE [dbo].[Buyer] (
    [BuyerOID]         INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeID]       VARCHAR (10)  NOT NULL,
    [PasswordHash]     VARCHAR (128) NOT NULL,
    [PasswordSalt]     VARCHAR (68)  NOT NULL,
    [AccountStatus]    VARCHAR (1)   NOT NULL,
    [CreateDate]       DATETIME      NOT NULL,
    [ModifiedDate]     DATETIME      NULL,
    [BSendLetterState] VARCHAR (1)   NULL,
    [BSendLetterDate]  DATETIME      NULL,
    CONSTRAINT [PK_Buyer] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Buyer_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購人員帳號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購人員帳號識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'BuyerOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'員工編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'EmployeeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'密碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'PasswordHash';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'密碼鹽', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'PasswordSalt';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'帳號狀態
R 重設 D 停用 E 啟用', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'AccountStatus';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'新增日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'CreateDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'更新日期時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'ModifiedDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'發信狀態
Y / N / S 
成功 / 失敗 / 發信中', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'BSendLetterState';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'發信時間', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Buyer', @level2type = N'COLUMN', @level2name = N'BSendLetterDate';

