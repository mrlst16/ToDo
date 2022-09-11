CREATE OR ALTER PROCEDURE GetAllItemsForUser
@userid int
As
Begin
Begin Transaction
Begin Try
select l.Id[ListId], l.Label[ListName], i.Id[ItemId], i.Label[ItemName], i.Status, i.Priority
from Lists(nolock) l
join Items i on l.Id = i.ToDoListId
where l.UserId = @userid
and l.DeletedUTC is null
and i.DeletedUTC is null

Commit Transaction
End Try
Begin Catch

if @@TRANCOUNT > 0
	Begin
		rollback transaction
	End
End catch
End