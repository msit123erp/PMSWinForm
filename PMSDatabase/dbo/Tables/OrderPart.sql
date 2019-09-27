CREATE TABLE [dbo].[OrderPart] (
    [OrderPartOID] INT            IDENTITY (1, 1) NOT NULL,
    [OrderID]      VARCHAR (14)   NOT NULL,
    [PartNumber]   NVARCHAR (10)  NOT NULL,
    [PartName]     NVARCHAR (30)  NOT NULL,
    [PartSpec]     NVARCHAR (128) NULL,
    [PartUnitName] NVARCHAR (6)   NOT NULL,
    [UnitPrice]    INT            NULL,
    CONSTRAINT [PK_OrderPart] PRIMARY KEY CLUSTERED ([OrderPartOID] ASC),
    CONSTRAINT [FK_OrderPart_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單料件總表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderPart';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單料件總表識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderPart', @level2type = N'COLUMN', @level2name = N'OrderPartOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderPart', @level2type = N'COLUMN', @level2name = N'OrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderPart', @level2type = N'COLUMN', @level2name = N'PartNumber';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件品名', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderPart', @level2type = N'COLUMN', @level2name = N'PartName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件規格', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderPart', @level2type = N'COLUMN', @level2name = N'PartSpec';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'料件單價', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderPart', @level2type = N'COLUMN', @level2name = N'UnitPrice';

