using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Teacher;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Teacher Teacher Data
    /// </summary>
    public class Teacher_Service : ITeacher_Service
    {
        //Reference to our crud functions
        private ITeacher_Operations _Teacher_operations = new Teacher_Operations();

        /// <summary>
        /// Obtains all the Teacher Teacheres that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Teacher_ResultSet>>> GetAllTeachers()
        {
            Generic_ResultSet<List<Teacher_ResultSet>> result = new Generic_ResultSet<List<Teacher_ResultSet>>();
            try
            {
                //GET ALL Teacher TeacherES
                List<Teacher> Teacheres = await _Teacher_operations.ReadAll();
                //MAP DB Teacher RESULTS
                result.result_set = new List<Teacher_ResultSet>();
                Teacheres.ForEach(s =>
                {
                    result.result_set.Add(new Teacher_ResultSet
                    {
                        Teacher_id = s.TeacherID,
                        name = s.Teacher_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Teacher Teacheres obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: GetAllTeachers() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Teacher Teacheres from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: GetAllTeachers(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Teacher_ResultSet>> GetTeacherById(long id)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {
                //GET by ID Teacher 
                var Teacher = await _Teacher_operations.Read(id);

                //MAP DB Teacher RESULTS
                result.result_set = new Teacher_ResultSet
                {
                    name = Teacher.Teacher_Name,
                    Teacher_id = Teacher.TeacherID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Teacher  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Teacher  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Teacher to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Teacher_ResultSet>> AddTeacher(string name)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Teacher
                Teacher Teacher = new Teacher
                {
                    Teacher_Name = name
                };

                //ADD Teacher TO DB
                Teacher = await _Teacher_operations.Create(Teacher);

                //MANUAL MAPPING OF RETURNED Teacher VALUES TO OUR Teacher_ResultSet
                Teacher_ResultSet TeacherAdded = new Teacher_ResultSet
                {
                    name = Teacher.Teacher_Name,
                    Teacher_id = Teacher.TeacherID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Teacher Teacher {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: AddTeacher() method executed successfully.";
                result.result_set = TeacherAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Teacher Teacher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: AddTeacher(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Teacher Teachers name.
        /// </summary>
        /// <param name="Teacher_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Teacher_ResultSet>> UpdateTeacher(Int64 Teacher_id, string name)
        {
            Generic_ResultSet<Teacher_ResultSet> result = new Generic_ResultSet<Teacher_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Teacher
                Teacher Teacher = new Teacher
                {
                    TeacherID = Teacher_id,
                    Teacher_Name = name,
                    //Teacher_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Teacher IN DB
                Teacher = await _Teacher_operations.Update(Teacher, Teacher_id);

                //MANUAL MAPPING OF RETURNED Teacher VALUES TO OUR Teacher_ResultSet
                Teacher_ResultSet TeacherUpdated = new Teacher_ResultSet
                {
                    name = Teacher.Teacher_Name,
                    Teacher_id = Teacher.TeacherID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Teacher Teacher {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: UpdateTeacher() method executed successfully.";
                result.result_set = TeacherUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Teacher Teacher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: UpdateTeacher(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteTeacher(long Teacher_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Teacher IN DB
                var TeacherDeleted = await _Teacher_operations.Delete(Teacher_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Teacher Teacher {0} was deleted successfully", Teacher_id);
                result.internalMessage = "LOGIC.Services.Implementation.Teacher_Service: DeleteTeacher() method executed successfully.";
                result.result_set = TeacherDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Teacher Teacher supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Teacher_Service: DeleteTeacher(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
