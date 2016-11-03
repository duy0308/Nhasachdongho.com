SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DzungHT
-- Create date: Ngày 03/11/2016
-- Description:	Lấy danh sách sản phẩm mới
-- =============================================
CREATE PROCEDURE sp_GetLstNewProduct
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP (120)
		[M].*
	FROM
		[M1Product] [M]
	WHERE
		[M].[Status] = 1 AND
		[M].[Showhome] = 1
		
END
GO
