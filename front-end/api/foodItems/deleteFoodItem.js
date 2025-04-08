import { API_BASE_URL } from "../constants"

export default async function deleteFoodItem(id) {
  const response = await fetch(API_BASE_URL + id, { method: "DELETE" });

  if (!response.ok) {
    throw new Error(`Failed to delete item with id: ${id}`);
  }

  return response.ok;
}