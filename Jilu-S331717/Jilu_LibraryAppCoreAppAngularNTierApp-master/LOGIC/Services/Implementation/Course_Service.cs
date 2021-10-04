using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using LOGIC.Services.Interfaces;
using LOGIC.Services.Models;
using LOGIC.Services.Models.Course;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LOGIC.Services.Implementation
{
    /// <summary>
    /// This service allows us to Add, Fetch and Update Course Course Data
    /// </summary>
    public class Course_Service : ICourse_Service
    {
        //Reference to our crud functions
        private ICourse_Operations _Course_operations = new Course_Operations();

        /// <summary>
        /// Obtains all the Course Coursees that exist in the database
        /// </summary>
        /// <returns></returns>
        public async Task<Generic_ResultSet<List<Course_ResultSet>>> GetAllCourses()
        {
            Generic_ResultSet<List<Course_ResultSet>> result = new Generic_ResultSet<List<Course_ResultSet>>();
            try
            {
                //GET ALL Course CourseES
                List<Course> Coursees = await _Course_operations.ReadAll();
                //MAP DB Course RESULTS
                result.result_set = new List<Course_ResultSet>();
                Coursees.ForEach(s =>
                {
                    result.result_set.Add(new Course_ResultSet
                    {
                        Course_id = s.CourseID,
                        name = s.Course_Name,
                    });
                });

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("All Course Coursees obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: GetAllCourses() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch all the required Course Coursees from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: GetAllCourses(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<Course_ResultSet>> GetCourseById(long id)
        {
            Generic_ResultSet<Course_ResultSet> result = new Generic_ResultSet<Course_ResultSet>();
            try
            {
                //GET by ID Course 
                var Course = await _Course_operations.Read(id);

                //MAP DB Course RESULTS
                result.result_set = new Course_ResultSet
                {
                    name = Course.Course_Name,
                    Course_id = Course.CourseID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("Get ByID - Course  obtained successfully");
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: Get ByID() method executed successfully.";
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed fetch Get ByID the required Course  from the database.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: Get ByID(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        /// <summary>
        /// Adds a new Course to the database
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Course_ResultSet>> AddCourse(string name)
        {
            Generic_ResultSet<Course_ResultSet> result = new Generic_ResultSet<Course_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Course
                Course Course = new Course
                {
                    Course_Name = name
                };

                //ADD Course TO DB
                Course = await _Course_operations.Create(Course);

                //MANUAL MAPPING OF RETURNED Course VALUES TO OUR Course_ResultSet
                Course_ResultSet CourseAdded = new Course_ResultSet
                {
                    name = Course.Course_Name,
                    Course_id = Course.CourseID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Course Course {0} was added successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: AddCourse() method executed successfully.";
                result.result_set = CourseAdded;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to register your information for the Course Course supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: AddCourse(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

        /// <summary>
        /// Updat an Course Courses name.
        /// </summary>
        /// <param name="Course_id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Generic_ResultSet<Course_ResultSet>> UpdateCourse(Int64 Course_id, string name)
        {
            Generic_ResultSet<Course_ResultSet> result = new Generic_ResultSet<Course_ResultSet>();
            try
            {
                //INIT NEW DB ENTITY OF Course
                Course Course = new Course
                {
                    CourseID = Course_id,
                    Course_Name = name,
                    //Course_ModifiedDate = DateTime.UtcNow 
                };

                //UPDATE Course IN DB
                Course = await _Course_operations.Update(Course, Course_id);

                //MANUAL MAPPING OF RETURNED Course VALUES TO OUR Course_ResultSet
                Course_ResultSet CourseUpdated = new Course_ResultSet
                {
                    name = Course.Course_Name,
                    Course_id = Course.CourseID
                };

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Course Course {0} was updated successfully", name);
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: UpdateCourse() method executed successfully.";
                result.result_set = CourseUpdated;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to update your information for the Course Course supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: UpdateCourse(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }


        public async Task<Generic_ResultSet<bool>> DeleteCourse(long Course_id)
        {
            Generic_ResultSet<bool> result = new Generic_ResultSet<bool>();
            try
            {
                //delete Course IN DB
                var CourseDeleted = await _Course_operations.Delete(Course_id);

                //SET SUCCESSFUL RESULT VALUES
                result.userMessage = string.Format("The supplied Course Course {0} was deleted successfully", Course_id);
                result.internalMessage = "LOGIC.Services.Implementation.Course_Service: DeleteCourse() method executed successfully.";
                result.result_set = CourseDeleted;
                result.success = true;
            }
            catch (Exception exception)
            {
                //SET FAILED RESULT VALUES
                result.exception = exception;
                result.userMessage = "We failed to Delete your information for the Course Course supplied. Please try again.";
                result.internalMessage = string.Format("ERROR: LOGIC.Services.Implementation.Course_Service: DeleteCourse(): {0}", exception.Message); ;
                //Success by default is set to false & its always the last value we set in the try block, so we should never need to set it in the catch block.
            }
            return result;
        }

    }
}
