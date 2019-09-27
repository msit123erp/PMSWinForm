CREATE TABLE [dbo].[OrderChangedCategory] (
    [OrderChangedCategoryCode] VARCHAR (1)   NOT NULL,
    [ChangeReson]              NVARCHAR (10) NOT NULL,
    CONSTRAINT [PK_OrderChangedCategory_1] PRIMARY KEY CLUSTERED ([OrderChangedCategoryCode] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'訂單異動分類', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChangedCategory';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'異動分類代碼
N：訂單新增、P：訂單已送出、C：訂單修改中、D：訂單取消、E：訂單成立、S：訂單已出貨', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChangedCategory', @level2type = N'COLUMN', @level2name = N'OrderChangedCategoryCode';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'異動原因', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'OrderChangedCategory', @level2type = N'COLUMN', @level2name = N'ChangeReson';

