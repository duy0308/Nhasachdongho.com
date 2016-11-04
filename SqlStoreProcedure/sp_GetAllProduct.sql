SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DzungHT
-- Create date: ngày 04/11/2016
-- Description:	Lấy tất cả sản phẩm
-- =============================================
CREATE PROCEDURE sp_GetAllProduct 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		* 
	FROM 
		M1Product M
	ORDER BY
		M.ModifiedDate DESC
END
GO
