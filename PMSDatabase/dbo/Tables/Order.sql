CREATE TABLE [dbo].[Order] (
    [OrderOID]          INT            IDENTITY (1, 1) NOT NULL,
    [OrderID]           VARCHAR (14)   NOT NULL,
    [PurchasingOrderID] VARCHAR (14)   NOT NULL,
    [SupplierCode]      NVARCHAR (6)   NOT NULL,
    [SupplierAccountID] VARCHAR (10)   NOT NULL,
    [EmployeeID]        VARCHAR (10)   NOT NULL,
    [DateRequired]      DATETIME       NULL,
    [DateReleased]      DATETIME       NULL,
    [ReceiverName]      NVARCHAR (30)  NULL,
    [ReceiverTel]       VARCHAR (30)   NULL,
    [ReceiverMobile]    VARCHAR (30)   NULL,
    [ReceiptAddress]    NVARCHAR (256) NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Order_Buyer] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Buyer] ([EmployeeID]),
    CONSTRAINT [FK_Order_Employee] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([EmployeeID]),
    CONSTRAINT [FK_Order_PurchasingOrder] FOREIGN KEY ([PurchasingOrderID]) REFERENCES [dbo].[PurchasingOrder] ([PurchasingOrderID]),
    CONSTRAINT [FK_Order_SupplierAccount] FOREIGN KEY ([SupplierAccountID]) REFERENCES [dbo].[SupplierAccount] ([SupplierAccountID]),
    CONSTRAINT [FK_Order_SupplierInfo] FOREIGN KEY ([SupplierCode]) REFERENCES [dbo].[SupplierInfo] ([SupplierCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單總表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單總表識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'OrderOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'OrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購單編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'PurchasingOrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'SupplierCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'供應商帳號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'SupplierAccountID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'員工編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'EmployeeID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'需求日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'DateRequired';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'承諾日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'DateReleased';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'收貨人姓名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'ReceiverName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'收貨人市話', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'ReceiverTel';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'收貨人手機', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'ReceiverMobile';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'收貨地址', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Order', @level2type = N'COLUMN', @level2name = N'ReceiptAddress';

