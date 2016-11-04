IF(EXISTS (SELECT * FROM sys.objects WHERE [name] = 'sp_GetAllMatHangbyMHLDefault' AND [type] = 'P'))
BEGIN
	DROP PROCEDURE [sp_GetAllMatHangbyMHLDefault]
END -- IF(EXISTS (SELECT * FROM sys.objects WHERE [name] = 'sp_GetAllMatHangbyMHLDefault' AND [type] = 'P'))
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		DzungHT
-- Create date: ngày 04/11/2016
-- Description:	Lấy sản phẩm theo groupID
-- =============================================
CREATE PROCEDURE sp_GetAllMatHangbyMHLDefault
	@id int
AS
BEGIN
	SET NOCOUNT ON;

	CREATE TABLE #results(id int)
	DECLARE @Level tinyint
	SELECT @Level = 1
	DECLARE @root int
	SELECT @root = @id
	CREATE TABLE #stack (id int, [Level] int)
	INSERT INTO #stack VALUES (@root, @Level)
	WHILE @Level > 0
	BEGIN
		IF EXISTS (SELECT * FROM #stack WHERE [Level] = @Level)
		BEGIN
			SELECT 
				@id = t.id
			FROM 
				#stack s 
			INNER JOIN M1ProductCategory t ON t.id = s.id
			WHERE s.[Level] = @Level

			INSERT INTO #results VALUES ( @id)

			DELETE FROM #stack WHERE [Level] = @Level AND id = @id
			INSERT #stack SELECT id, @Level + 1 FROM M1ProductCategory WHERE ParentID = @id

			IF @@ROWCOUNT > 0 
			  BEGIN
				SELECT @Level = @Level + 1
			END
		END--IF EXISTS
		ELSE
		BEGIN
		   SELECT @Level = @Level - 1
		END -- ELSE
	END -- WHILE

	SELECT TOP (12) 
		*,
		CONVERT (int,Quantity) as SoLuonga,
		PARSENAME(CONVERT(varchar,CONVERT(money,Price),1),2) as banle ,
		LEFT(Quantity,2)as SoLuongs,
		CASE WHEN Quantity=0 THEN N'Liên hệ' ELSE LEFT(Quantity,2) END Soluonghang 
	FROM  M1Product 
	WHERE 
		CategoryID IN ( SELECT ID FROM #results)

	
END -- Create proc
GO
