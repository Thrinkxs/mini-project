import { useQuery } from "@tanstack/react-query";
import { type Company } from "@/utils/types";
import { Axios } from "@/utils/Axios";

const fetchCompanies = async () => {
try {
    const response = await Axios.get(`/api/company/get-companies`);
    if ( response.status !== 200) {
        throw new Error("An error occured");
    }
    const data: Company[] = await response.data;
    return data;
}

catch (error) {
    console.error("An error occured",error);
}
}


export const useFetchCompanies = () => {
    return useQuery({
        queryKey: ["companies"],
        queryFn: () => fetchCompanies(),
        retryDelay: 500,
        retry: 3,
    })
};