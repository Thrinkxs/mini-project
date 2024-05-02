import { NextApiRequest, NextApiResponse } from "next";
import { NextRequest, NextResponse } from "next/server";
import { prisma } from "@/prisma/migrations/client";

export async function POST(req: Request, res: Response) {
  try {
    const { name, phone } = await req.json();
    const company = await prisma.company.create({
      data: {
        name,
        phone,
      },
    });

    return Response.json({
      message: "Company created successfully",
      company,
    });
  } catch (error) {
    return NextResponse.json({
      error: error,
      message: "Company creation failed",
    });
  }
}
