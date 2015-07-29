using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ManageDistricts : MonoBehaviour {

	private enum District	{RESIDENTIAL,
							SHOPPING,
							FARMING,
							TOURIST,
							BUSINESS};
	private District currDistrict = District.RESIDENTIAL;

	public Text DistrictText;

	void Start()
	{
				DistrictText.text = "Residential District";
		}

	// Update is called once per frame
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Residential") {
			DistrictText.text = "Residential District";
			currDistrict = District.RESIDENTIAL;
		}
		else if(col.tag == "Shopping")
		{
			DistrictText.text = "Shopping District";
			currDistrict = District.SHOPPING;
		}
		else if(col.tag == "Farming")
		{
			DistrictText.text = "Farming District";
			currDistrict = District.FARMING;
		}
		else if(col.tag == "Tourist")
		{
			DistrictText.text = "Tourist District";
			currDistrict = District.TOURIST;
		}
		else if(col.tag == "Business")
		{
			DistrictText.text = "Business District";
			currDistrict = District.BUSINESS;
		}
	}

	public string GetDistrict()
	{
		return DistrictText.text;
	}
}
