using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PackageTest.Dtos
{
    public class ChangeDto
    {
        public int Id { get; set; }

        /// <summary>
        /// 变动源组织架构Id
        /// </summary>
        public string SourceId { get; set; }

        /// <summary>
        /// 记录类型
        /// </summary>
        public string RecordType { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// 变动方式
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// 修改字段和修改的值(旧的内容和新的内容以','分隔)
        /// </summary>
        public Dictionary<string, string> ChangedProperties { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// 改变记录是否有效。 撤销此次变动时将把管理的变动记录改为无效状态
        /// </summary>
        public bool? IsActive { get; set; } = null;
    }
}
