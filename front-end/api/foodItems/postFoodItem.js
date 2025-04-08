import { API_BASE_URL } from "../constants";

export default async function postFoodItem(newItem) {
  const response = await fetch(API_BASE_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(newItem)
  });

  if (!response.ok) {
    throw new Error(`Failed to post new item: ${newItem}`);
  }

  return response.json();
}