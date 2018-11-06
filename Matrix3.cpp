#include "stdafx.h"
#include "Matrix3.h"

Matrix3 Matrix3::operator*(const Matrix3 & Mat) const
{
	Matrix3 result;

	result._11 = _11 * Mat._11 + _12 * Mat._21 + _13 * Mat._31;
	result._12 = _11 * Mat._12 + _12 * Mat._22 + _13 * Mat._32;
	result._13 = _11 * Mat._13 + _12 * Mat._23 + _13 * Mat._33;

	result._21 = _21 * Mat._11 + _22 * Mat._21 + _23 * Mat._31;
	result._22 = _21 * Mat._12 + _22 * Mat._22 + _23 * Mat._32;
	result._23 = _21 * Mat._13 + _22 * Mat._23 + _23 * Mat._33;

	result._31 = _31 * Mat._11 + _32 * Mat._21 + _33 * Mat._31;
	result._32 = _31 * Mat._12 + _32 * Mat._22 + _33 * Mat._32;
	result._33 = _31 * Mat._13 + _32 * Mat._23 + _33 * Mat._33;

	return result;
}
