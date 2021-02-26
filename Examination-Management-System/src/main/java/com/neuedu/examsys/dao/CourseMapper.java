package com.neuedu.examsys.dao;

import java.util.List;

import org.apache.ibatis.annotations.Mapper;

import com.neuedu.examsys.domain.Course;

@Mapper
public interface CourseMapper {
	public void insertCourse(Course course);
	public List<Course> queryCourse();
	public List<Course> selectCourse(String id);
	public void deleteCourse(String id);
	public void updateCourse(Course course);
}
