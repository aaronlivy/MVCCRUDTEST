namespace MVCCRUDTEST.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static MemeberRepository GetMemeberRepository()
		{
			var repository = new MemeberRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static MemeberRepository GetMemeberRepository(IUnitOfWork unitOfWork)
		{
			var repository = new MemeberRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}