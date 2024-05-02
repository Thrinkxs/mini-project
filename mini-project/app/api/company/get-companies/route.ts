import { prisma } from "@/prisma/migrations/client";
import { NextRequest, NextResponse } from "next/server";


export async function GET(req: Request, res: Response) {
  try {
    const companies = await prisma.company.findMany();
    if (!companies) {
      return NextResponse.json({ error: "No companies found" });
    }
    return NextResponse.json(companies);
  } catch (error) {
    return NextResponse.json({ error});
  }
}