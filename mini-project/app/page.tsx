"use client";
import { columns } from "@/components/CompanyColumn/CompanyColumn";
import { DataTable } from "@/components/ui/data-table";
import { useFetchCompanies } from "@/hooks/companies/companies";
import Image from "next/image";
import { TbLoader2 } from 'react-icons/tb'


export default function Home() {
  const {data, isLoading} = useFetchCompanies()


if (isLoading) {
  <div className='flex items-center flex-col gap-3 text-purple-500'>
  <TbLoader2 className='w-10 h-10 animate-spin' />
  <p>Loading settings...</p>
</div>
}

  return (
    <main className="">
      <div className="flex flex-col mx-20">
      <h1 className="text-lg font-bold capitalize">View all company suppliers</h1>
      <DataTable columns={columns} data={data || []} noDataMessage="No company found" showNameFilter={true}/>
    
      </div>
     </main>
  );
}
