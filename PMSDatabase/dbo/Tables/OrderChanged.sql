CREATE TABLE [dbo].[OrderChanged] (
    [OrderChangedOID]          INT          IDENTITY (1, 1) NOT NULL,
    [OrderID]                  VARCHAR (14) NOT NULL,
    [OrderChangedCategoryCode] VARCHAR (1)  NOT NULL,
    [RequestDate]              DATETIME     NOT NULL,
    [RequesterRole]            VARCHAR (1)  NOT NULL,
    [RequesterID]              VARCHAR (10) NOT NULL,
    CONSTRAINT [PK_OrderChanged] PRIMARY KEY CLUSTERED ([OrderChangedOID] ASC),
    CONSTRAINT [FK_OrderChanged_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID]),
    CONSTRAINT [FK_OrderChanged_OrderChangedCategory] FOREIGN KEY ([OrderChangedCategoryCode]) REFERENCES [dbo].[OrderChangedCategory] ([OrderChangedCategoryCode])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單異動總表', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChanged';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單異動總表識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChanged', @level2type = N'COLUMN', @level2name = N'OrderChangedOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單編號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChanged', @level2type = N'COLUMN', @level2name = N'OrderID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'異動提出日期', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChanged', @level2type = N'COLUMN', @level2name = N'RequestDate';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'角色帳號', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChanged', @level2type = N'COLUMN', @level2name = N'RequesterID';

