import { Company } from "@/utils/types"
import { ColumnDef } from "@tanstack/react-table"
 
export const columns: ColumnDef<Company>[] = [
  {
    accessorKey: "name",
    header: "Company Name",
  },
  {
    accessorKey: "phone",
    header: "Phone Number",
  }
]