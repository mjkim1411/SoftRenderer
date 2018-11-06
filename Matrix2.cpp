#include "stdafx.h"
#include "Matrix2.h"

Matrix2 Matrix2::operator*(const Matrix2 & Mat) const
{
	Matrix2 result;
	result._11 = _11 * Mat._11 + _12 * Mat._21;
	result._12 = _11 * Mat._12 + _12 * Mat._22;
	result._21 = _21 * Mat._11 + _22 * Mat._21;
	result._22 = _21 * Mat._12 + _22 * Mat._22;
	return result;
}
