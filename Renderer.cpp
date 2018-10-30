#include "stdafx.h"
#include "SoftRenderer.h"
#include "GDIHelper.h"
#include "Renderer.h"
#include "Vector.h"
#include "IntPoint.h"
#include "Matrix.h"

bool IsInRange(int x, int y);
void PutPixel(int x, int y);

bool IsInRange(int x, int y)
{
	return (abs(x) < (g_nClientWidth / 2)) && (abs(y) < (g_nClientHeight / 2));
}

void PutPixel(int x, int y)
{
	if (!IsInRange(x, y)) return;

	ULONG* dest = (ULONG*)g_pBits;
	DWORD offset = g_nClientWidth * g_nClientHeight / 2 + g_nClientWidth / 2 + x + g_nClientWidth * -y;
	*(dest + offset) = g_CurrentColor;
}

void PutPixel(const IntPoint& inPt)
{
	PutPixel(inPt.X, inPt.Y);
}


void UpdateFrame(void)
{
	// Buffer Clear RGB
	SetColor(32, 128, 255);
	Clear();

	// Draw
	SetColor(255, 0, 0);

	//Draw a circle with radius 100
	Vector2 center(0.0f, 0.0f);
	float radius = 100.0f;
	int nradius = (int)radius;

	static float degree = 0;
	degree += 0.1f;
	degree = fmodf(degree, 360.0f);

	Matrix2 rotMat;
	rotMat.SetRotation(degree);

	for (int i = nradius; i <= nradius; i++)
	{
		for (int j = -nradius; j <= nradius; j++)
		{
			PutPixel(Vector2(i, j)*rotMat);
		}
	}

	Matrix2 scaleMat;
	scaleMat.SetScale(2.0f, 0.5f);

	Matrix2 rotatemat;
	rotatemat.SetRotation(degree);


	Matrix2 SRMAT = scaleMat * rotatemat;
	Matrix2 RSMAT = rotatemat * scaleMat;
	//for (int i = -nradius; i <= nradius; i++)
	//{
	//	for (int j = 0/*-nradius*/; j <= nradius; j++)
	//	{
	//		IntPoint pt(i, j);
	//		Vector2 ptVec = pt.ToVector2();
	//		if (Vector2::DistSquared(center, pt.ToVector2()) < radius*radius)
	//		{
	//			//IntPoint scaledPt = IntPoint(ptVec * scaleMat);
	//			//IntPoint rotatePt = IntPoint(ptVec * rotatemat);
	//			IntPoint SRPt(ptVec * SRMAT);
	//			IntPoint RSPt(ptVec * RSMAT);
	//			PutPixel(SRPt);
	//			
	//		}
	//	}
	//}

	/*for (int i = 0; i <= 360; i++)
	{
	rotatemat.SetRotation((float)i);
	IntPoint pt(radius, 0);
	Vector2 ptvec = pt.ToVector2();
	IntPoint rotatePt = IntPoint(ptvec*rotatemat);
	PutPixel(rotatePt);
	}*/

	// Buffer Swap 
	BufferSwap();
}