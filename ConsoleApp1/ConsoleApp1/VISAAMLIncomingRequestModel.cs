using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VISAALMIncomingAPI.WF
{
    [DataContract]
    public class VISAAMLIncomingRequestModel
    {
        /// <summary>
        /// messageReasonCode
        /// <Required>C</Required>
        /// </summary>
        [DataMember]
        [Required]
        public string messageReasonCode { get; set; }
        /// <summary>
        /// dateTimeOfEvent
        /// <Required>C</Required>
        /// </summary>
        [DataMember]
        [Required]
        public string dateTimeOfEvent { get; set; }
        /// <summary>
        /// updateReferenceID
        /// <Required>C</Required>
        /// </summary>
        [DataMember]
        [Required]
        public string updateReferenceID { get; set; }
        /// <summary>
        /// encryptedData
        /// <Required>C</Required>
        /// </summary>
        [DataMember]
        [Required]
        public string encryptedData { get; set; }
        /// <summary>
        /// responseStatus
        /// </summary>
        [DataMember]
        public string responseStatus { get; set; }
        /// <summary>
        /// rejectCode
        /// </summary>
        [DataMember]
        public string rejectCode { get; set; }
        /// <summary>
        /// rejectDesc
        /// </summary>
        [DataMember]
        public string rejectDesc { get; set; }
        /// <summary>
        /// rejectDesc
        /// </summary>
        [DataMember]
        public string groupID { get; set; }
        /// <summary>
        /// rejectDesc
        /// </summary>
        [DataMember]
        public string groupType { get; set; }
    }
}
