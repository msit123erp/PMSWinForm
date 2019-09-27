CREATE TABLE [dbo].[SourceOrderList] (
    [SourceOrderListOID] INT            IDENTITY (1, 1) NOT NULL,
    [OrderPartOID]       INT            NOT NULL,
    [Batch]              INT            NOT NULL,
    [Discount]           DECIMAL (3, 2) NOT NULL,
    [Qty]                INT            NOT NULL,
    CONSTRAINT [PK_SourceOrderList] PRIMARY KEY CLUSTERED ([SourceOrderListOID] ASC),
    CONSTRAINT [FK_SourceOrderList_OrderPart] FOREIGN KEY ([OrderPartOID]) REFERENCES [dbo].[OrderPart] ([OrderPartOID])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購單貨源清單', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceOrderList';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購單貨源清單識別碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceOrderList', @level2type = N'COLUMN', @level2name = N'SourceOrderListOID';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'貨源清單批量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceOrderList', @level2type = N'COLUMN', @level2name = N'Batch';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'貨源清單折扣', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceOrderList', @level2type = N'COLUMN', @level2name = N'Discount';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'採購數量', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'SourceOrderList', @level2type = N'COLUMN', @level2name = N'Qty';

