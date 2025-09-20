using StudentsManager.Domain.Common;

namespace StudentsManager.Application.Common.Interfaces.Repositories
{
    /// <summary>
    /// Интерфейс общего репозитория
    /// </summary>
    /// <typeparam name="TEntity">Параметр сущности</typeparam>
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        /// <summary>
        /// Получить все сущности
        /// </summary>
        /// <returns>Список сущностей</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// Получает конкретную сущность
        /// </summary>
        /// <param name="id">Идентификатор сущности</param>
        /// <returns>Возращает сущность; если сущность не найдена возращает null</returns>
        Task<TEntity?> GetByIdAsync(int id);
        /// <summary>
        /// Создает сущность
        /// </summary>
        /// <param name="entity">Объект сущности</param>
        Task CreateAsync(TEntity entity);
        /// <summary>
        /// Редактирует сущность
        /// </summary>
        /// <param name="entity">Объект сущности</param>
        Task UpdateAsync(TEntity entity);
        /// <summary>
        /// Удаляет сущность
        /// </summary>
        /// <param name="entity">Объект сущности</param>
        Task DeleteAsync(TEntity entity);
    }
}
