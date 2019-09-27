CREATE TABLE [dbo].[PurchasingOrder] (
    [PurchasingOrderOID] INT          IDENTITY (1, 1) NOT NULL,
    [PurchasingOrderID]  VARCHAR (14) NOT NULL,
    [EmployeeID]         VARCHAR (10) NOT NULL,
    [POBeginDate]        DATETIME     NOT NULL,
    CONSTRAINT [PK_PurchasingOrder] PRIMARY KEY CLUSTERED ([PurchasingOrderID] ASC),
    CONSTRAINT [FK_PurchasingOrder_Buyer] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Buyer] ([EmployeeID]),
    CONSTRAINT [FK_PurchasingOrder_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購單總表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PurchasingOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購單識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PurchasingOrder', @level2type = N'COLUMN', @level2name = N'PurchasingOrderOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購單編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PurchasingOrder', @level2type = N'COLUMN', @level2name = N'PurchasingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'員工編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PurchasingOrder', @level2type = N'COLUMN', @level2name = N'EmployeeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購單產生日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'PurchasingOrder', @level2type = N'COLUMN', @level2name = N'POBeginDate';

