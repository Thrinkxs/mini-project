import type { Metadata } from "next";
import { Inter } from "next/font/google";
import "./globals.css";
import NavBar from "@/components/NavBar";
import { Toaster } from "sonner";
import TanstackProvider from "../utils/TanstackProvider";

const inter = Inter({ subsets: ["latin"] });

export const metadata: Metadata = {
  title: "Supplier's connect",
  description: "Connecting sales and suppliers",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={inter.className}>
        <TanstackProvider>
          <NavBar />
          <Toaster position="top-right" />
          {children}
        </TanstackProvider>
      </body>
    </html>
  );
}
