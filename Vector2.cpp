#include "stdafx.h"
#include "Vector2.h"

float Vector2::Dist(const Vector2 & V1, const Vector2 & V2)
{
	return sqrtf(Vector2::DistSquared(V1, V2));
}

float Vector2::DistSquared(const Vector2 & V1, const Vector2 & V2)
{
	float xLength = V2.X - V1.X;
	float yLength = V2.Y - V1.Y;
	return xLength * xLength + yLength * yLength;
}

Vector2 Vector2::operator*(const Matrix2 & Mat) const
{
	Vector2 result;
	result.X = X * Mat._11 + Y * Mat._12;
	result.Y = X * Mat._21 + Y * Mat._22;
	return result;
}

bool Vector2::Equals(const Vector2 & V, float tolerance) const
{
	return (fabs(X - V.X) <= tolerance) && (fabs(Y - V.Y) <= tolerance);
}
